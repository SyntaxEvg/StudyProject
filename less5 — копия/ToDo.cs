using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Linq;
namespace less5
{
    internal class ToDo
    {
        [JsonIgnore]
       public static List<ToDo> GetTask = new List<ToDo>();
        [DataMember]
        public string Title { get;  set; }
        [DataMember]
        public bool IsDone { get;  set; }=true;
        [DataMember]
        public int id { get; set; }



        public ToDo Edit(int id)
        {
           return GetTask.FirstOrDefault(x => x.id == id);         
        }


        public void Save(string file)
        {
          
            try
            {
                var convertedJson = JsonConvert.SerializeObject(GetTask, Formatting.Indented);
                File.WriteAllText(file, JsonConvert.SerializeObject(convertedJson));
            }
            catch (Exception)
            {
                Console.WriteLine("Save error");
            }
        }

        internal void EditNumTask(ToDo ts,int newNum)
        {
            //var ts= Edit(num);
            if (ts!= null)
            {
                var tempstr= ts.Title;
                var edit=new ToDo()
                {
                    Title = tempstr,
                    IsDone = ts.IsDone,
                    id = newNum
                };
                GetTask.Remove(ts);
                GetTask.Add(edit);
            }
        }

        internal void AddTask(string title, int ids,bool flag=true )
        {
            var a= Edit(ids);
            if (a!=null)
            {
                GetTask.Remove(a);
            }
            GetTask.Add(new ToDo(){Title=title, IsDone=flag,id=ids});
        }

         public IEnumerable<ToDo> LoadFile(string puth)
        {
            using (StreamReader file = File.OpenText(puth))
            {
                JsonSerializer serializer = new JsonSerializer();
                var massResult = (List<ToDo>)serializer.Deserialize(file, typeof(List<ToDo>));
                GetTask.AddRange(massResult);
            }
            var GetTaskSort=GetTask.OrderBy(x=> x.id).ToList();
            foreach (var item in GetTaskSort)
            {
                yield return item;
            }
        }

       
    }
}