using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class grades
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("student_id")]
        public String student_id { get; set; }
    //    [BsonElement("scores")]
    //    public int[] scores { get; set; }
        [BsonElement("class_id")]
        public double class_id { get; set; }

        public grades(string student_id, double class_id)
        {
            this.student_id = student_id;
            this.class_id = class_id;
        }
    }
}
