using System;

namespace TheBezitEstateApp.Data.Entities
{
    public abstract class BaseEntity
    {
        public string Id {get; set;}

        public bool IsDeleted {get; set;}
        
        public DateTime CreatedAt {get; set;}

        public DateTime ModifiedAt {get; set;}

        public DateTime DeleteAt {get; set;}



        
    }
}