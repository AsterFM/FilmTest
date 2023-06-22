namespace FilmApi.Data;
using System.Net;
using System.Text.Json;

public class FullInfo
{

    public class FilmItem
    {
        public string name_russian { get; set; }
        public string description { get; set; }
        public string year { get; set; }
        public float rating_kp { get; set; }
        public float rating_imdb { get; set; }
        public string time { get; set; }
        public string premiere_ru { get; set; }
        public string budget { get; set; }
        public string age_restriction { get; set; }
        public string country_ru { get; set; }
        public string big_poster { get; set; }
    }
    
    public FullInfo.FilmItem Film(FilmItem FilmInfo, int page, int id)
    {
        FilmItem filmItem = new FilmItem();
        var webClient = new WebClient();
        string jsonUri = "https://kinobd.ru/api/films?page=" + page;

        string jsonString =  webClient.DownloadString(jsonUri);

        var jsonDocument = JsonDocument.Parse(jsonString);
        var filmArray = jsonDocument.RootElement.GetProperty("data");
        var filmElement = filmArray[id];
        filmItem = JsonSerializer.Deserialize<FilmItem>(filmElement);
        FilmInfo.name_russian = filmItem.name_russian;
        FilmInfo.big_poster = filmItem.big_poster;
        FilmInfo.description = filmItem.description;
        FilmInfo.year = filmItem.year;
        FilmInfo.rating_kp = filmItem.rating_kp;
        FilmInfo.rating_imdb = filmItem.rating_imdb;
        FilmInfo.time = filmItem.time;
        FilmInfo.premiere_ru = filmItem.premiere_ru;
        FilmInfo.budget = filmItem.budget;
        FilmInfo.age_restriction = filmItem.age_restriction;
        FilmInfo.country_ru = filmItem.country_ru;

        return FilmInfo;
    }
}



