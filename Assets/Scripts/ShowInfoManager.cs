using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using Assets;

public class ShowInfoManager : MonoBehaviour
{
    private GameObject previousObject;
    public GameObject canvasObject; // Tham chiếu đến Canvas từ Inspector
    private string connectionString = "URI=file:" +Application.dataPath +"/sample.sqlite";
    public GameObject ScorePrelab;

    public UnityEngine.Transform scoreParent;
    List<Info> infolst = new List<Info>();

    // Start is called before the first frame update
    void Start()
    {

        //getScore();
        GameObject canvasObject = GameObject.Find("Canvas");
        canvasObject.SetActive(false); // Ẩn toàn bộ canvas


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Kiểm tra khi nhấn chuột trái
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Kiểm tra xem có nhấn vào bất kỳ đối tượng nào trong cảnh hay không
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Hiển thị Canvas khi nhấn vào một đối tượng


                // Lấy đối tượng đã click vào
                GameObject clickedObject = hitInfo.collider.gameObject;

                try
                {
                    Info info = FindScoreByName(clickedObject.name);
                    Debug.Log(clickedObject.name);
                    Debug.Log(info);
                    if (info != null)
                    {
                        ShowScore(info);
                        canvasObject.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Info is null, cannot display score.");
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Error occurred while showing score: " + e.Message);
                }




                // Hiển thị thông báo Debug khi click vào đối tượng
                Debug.Log("Clicked on object: " + clickedObject.name);

                // Ở đây bạn có thể cập nhật nội dung UI của Canvas nếu cần
            }
            else
            {
                // Nếu không nhấn vào bất kỳ đối tượng nào thì tắt Canvas
                canvasObject.SetActive(false);
            }
        }
    }

    public void getScore()
    {
        infolst.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                String sql = "SELECT * FROM HighScore";
                dbCmd.CommandText = sql;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infolst.Add(new Info(reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4)));
                        Debug.Log(reader.GetString(1));

                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }
    public Info FindScoreByName(string playerName)
    {
        infolst.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                // Sử dụng câu lệnh SQL có điều kiện WHERE để tìm theo Name
                string sql = "SELECT * FROM HighScore WHERE Name = @Name";
                dbCmd.CommandText = sql;
                IDbDataParameter nameParam = dbCmd.CreateParameter();
                nameParam.ParameterName = "@Name";
                nameParam.Value = playerName;
                dbCmd.Parameters.Add(nameParam);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Lấy thông tin từ cơ sở dữ liệu và thêm vào danh sách
                        infolst.Add(new Info(
                             reader.GetString(1),
                             reader.GetString(2),
                             reader.GetString(3),
                             reader.GetString(4)
                         ));
                    }

                    reader.Close();
                }
                dbConnection.Close();
            }
        }

        return infolst[0]; // Trả về danh sách kết quả
    }
    public void ShowScore(Info infoShow)
    {
        // Nếu đối tượng cũ đã tồn tại, hủy nó trước khi tạo đối tượng mới
        if (previousObject != null)
        {
            Destroy(previousObject); // Hủy đối tượng cũ
        }

        // Tạo đối tượng mới
        GameObject tmpObject = Instantiate(ScorePrelab);
        Info info = infoShow;

        // Cập nhật thông tin cho đối tượng mới
        tmpObject.GetComponent<ShowInfo>().SetScore(info.Category, info.Name, info.AuthorName, info.Instructor);

        // Gán parent và thiết lập vị trí cho đối tượng mới
        tmpObject.transform.SetParent(scoreParent);
        tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(67, -77, 0);

        // Gán đối tượng mới vào biến previousObject để sử dụng trong lần sau
        previousObject = tmpObject;
    }
}
