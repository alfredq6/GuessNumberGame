using Dal.Helper;
using Dal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        public string AppPath = Environment.CurrentDirectory;
        public string FolderName;


        public BaseRepository(string folderName)
        {
            FolderName = folderName;
            var folderPath = Path.Combine(AppPath, FolderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }


        public T Get(int id)
        {
            var fileName = $"{id}.json";
            var path = Path.Combine(AppPath, FolderName, fileName);
            if (!File.Exists(path))
            {
                return null;
            }

            using (var sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();
                var model = JSONSerializeHelper.Desirialize<T>(json);
                return model;
            }
        }

        public void Save(T model)
        {

            var fileName = $"{model.Id}.json";

            var path = Path.Combine(AppPath, FolderName, fileName);
            var json = JSONSerializeHelper.Serilialize(model);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
            }
        }
    }
}
