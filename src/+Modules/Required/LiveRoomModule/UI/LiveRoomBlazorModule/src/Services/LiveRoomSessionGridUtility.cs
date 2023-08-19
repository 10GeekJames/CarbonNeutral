using System.Drawing;

public static class LiveRoomSessionGridUtility
{
    public static string ConvertRowCellArrayToString(char[,] rowCells)
    {
        if (rowCells.Length > 0)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(rowCells);
        }
        return "";
    }
    public static char[,] ConvertRowCellStringToArray(string rowCellString)
    {
        if (rowCellString.Length > 0)
        {
            var rowCellArray = Newtonsoft.Json.JsonConvert.DeserializeObject<char[,]>(rowCellString);
            return rowCellArray;
        }
        return new char[0,0];
    }


    public static List<Point>? ConvertSelectedWordsToPointList(string completedWords)
    {
        if (completedWords.Length > 0)
        {
            var completedWordsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Point>>(completedWords);
            return completedWordsList;
        }
        return new();
    }
}