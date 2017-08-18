using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Book.Models;

namespace Book.Models
{
    public class Auction : BaseEntity
    {
        public int AuctionId { get; set; }
        
        public string AuctionName { get; set; }
        
        public string Context { get; set; }

        public Double AmountBid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
