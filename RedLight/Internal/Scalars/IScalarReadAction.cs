using System.Collections.Generic;
using System.Data.Common;

namespace RedLight.Internal;

public interface IScalarReadAction
{
    object Read(DbDataReader reader, int index);

    //void Read(List<T> list, DbDataReader reader)
    //{
    //    while (reader.Read())
    //        list.Add(Read(reader, 0));
    //}

    //public void Read(HashSet<T> list, DbDataReader reader)
    //{
    //    while (reader.Read())
    //        list.Add(Read(reader, 0));
    //}

    //public void Read(ICollection<T> list, DbDataReader reader)
    //{
    //    while (reader.Read())
    //        list.Add(Read(reader, 0));
    //}

}
