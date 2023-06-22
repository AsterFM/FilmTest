using System.Net;
using System.Text.Json;
using System.Net.Http;

namespace FilmApi.Data;

public class FilmPage
{
    public class FilmItem
    {
        public int page = 1;
        public string name_russian { get; set; }
        public string year { get; set; }
        public string big_poster { get; set; }
    }

    public FilmItem filmItem = new FilmItem();
    
    public List<FilmItem> Film(List<FilmItem> InfoList)
    {
        var webClient = new WebClient();
        string jsonUri = "https://kinobd.ru/api/films?page=" + filmItem.page;

        string jsonString =  webClient.DownloadString(jsonUri);

        var jsonDocument = JsonDocument.Parse(jsonString);
        var filmArray = jsonDocument.RootElement.GetProperty("data").EnumerateArray();

        foreach (var filmElement in filmArray)
        {
            FilmItem Inf = new FilmItem();
            FilmItem film = JsonSerializer.Deserialize<FilmItem>(filmElement.GetRawText());
            Inf.name_russian = film.name_russian;
            Inf.year = film.year;
            Inf.big_poster = film.big_poster;
            InfoList.Add(film);
        }

        return InfoList;
    }
}