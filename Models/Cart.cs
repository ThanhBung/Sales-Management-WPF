using System;
using System.Collections.Generic;

namespace SE1611_Group3_A2.Models
{
    public partial class Cart
    {
        public int RecordId { get; set; }
        public string CartId { get; set; } = null!;
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public Cart(string cartId, int albumId, int count, DateTime dateCreated)
        {
            CartId = cartId;
            AlbumId = albumId;
            Count = count;
            DateCreated = dateCreated;
        }

        public virtual Album Album { get; set; } = null!;
    }
}
