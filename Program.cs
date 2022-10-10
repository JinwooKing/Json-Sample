using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;

//1. 옵션 설정(JsonSerializerOptions)
var options = new JsonSerializerOptions 
{
    //Encoder : 문자 인코딩 사용자 지정
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
    //WriteIndented : 사용자 가독성을 위해 JSON의 서식을 지정
    WriteIndented = true 
};

//2. 객체 생성
Person person = new Person()
{
    Name = "박진우",
    Age = DateTime.Now.Year - 1994,
    Nickname = new string[] { "원빈", "장동건", "현빈" },
    Favoritefood = new List<string>() { "소고기", "돼지고기", "닭고기"},
    Birthday = DateTime.Parse("1994-08-09"),
    Employed = true
};

//3. 직렬화(객체를 JSON으로)
string jsonString = JsonSerializer.Serialize(person, options);
Console.WriteLine(jsonString);

jsonString = @"
{
  ""Name"": ""박진우"",
  ""Age"": 28,
  ""Nickname"": [
    ""원빈"",
    ""장동건"",
    ""현빈""
  ],
  ""Favoritefood"": [
    ""소고기"",
    ""돼지고기"",
    ""닭고기""
  ],
  ""Birthday"": ""1994-08-09T00:00:00+09:00"",
  ""Employed"": true
}

";

//4. 역직렬화(JSON을 객체로)
Person Person = JsonSerializer.Deserialize<Person>(jsonString);
Console.WriteLine(Person.Name);
Console.WriteLine(Person.Age);
Console.WriteLine(Person.Nickname);
Console.WriteLine(Person.Favoritefood);
Console.WriteLine(Person.Birthday);
Console.WriteLine(Person.Employed);

//5. JsonNode (역직렬화할 클래스가 없는 경우)
JsonNode jsonNode = JsonNode.Parse(jsonString);
Console.WriteLine(jsonNode.ToJsonString(options));
Console.WriteLine(jsonNode["Name"]);
Console.WriteLine(jsonNode["Age"]);
Console.WriteLine(jsonNode["Nickname"]);
Console.WriteLine(jsonNode["Favoritefood"].ToJsonString(options));
Console.WriteLine(jsonNode["Birthday"]);
Console.WriteLine(jsonNode["Employed"]);

#region 객체 정의
public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string[]? Nickname { get; set; }
    public List<string>? Favoritefood { get; set; }
    public DateTimeOffset Birthday { get; set; }
    public bool Employed { get; set; }
    public int Add(int a, int b)
    {
        return a + b;
    }
}
#endregion