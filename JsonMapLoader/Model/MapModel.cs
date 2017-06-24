using System;
using System.Collections;
using System.Runtime.Serialization;

namespace JsonMapLoader.Model
{

    [DataContract]
    public class MapModel
    {
        [DataMember]
        public string MapName { set; get; }
        [DataMember]
        public string MapVersion { set; get; }
        [DataMember]
        public string MapAuthor { set; get; }
        [DataMember]
        public Coordinate MapSize { set; get; }
        [DataMember]
        public Cell[] MapCells { set; get; }

        public bool MapSelfCheck()
        {
            if (MapCells == null || MapCells.Length > (MapSize.X * MapSize.Y))
                throw new Exception("Structure check failed");
            IEnumerator cellEnumerator = MapCells.GetEnumerator();
            while (cellEnumerator.Current != null)
            {
                Cell cell = (Cell)cellEnumerator.Current;
                if (cell.X < 0 || cell.Y < 0 || cell.X >= MapSize.X || cell.Y >= MapSize.Y)
                {
                    throw new Exception("Map cell out of size limitations.");
                }
                cellEnumerator.MoveNext();
            }
            string[] versionSegment = MapVersion.Split('.');
            int i = 0;
            int value = -1;
            while (i < versionSegment.Length)
            {
                if (!int.TryParse(versionSegment[i], out value))
                {
                    throw new Exception("Version not correct.");
                }
                i++;
            }
            return true;
        }
    }


    [DataContract]
    public class Coordinate
    {
        [DataMember]
        public int X { set; get; }
        [DataMember]
        public int Y { set; get; }
    }

    [DataContract]
    public class Cell : Coordinate
    {
        [DataMember]
        public CellType Type { set; get; }
    }

    public enum CellType
    {
        Wall = 0,
        Grass = 1,
        Water = 2,
        Default = 3
    }
}
