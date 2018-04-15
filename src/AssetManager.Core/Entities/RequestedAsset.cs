﻿using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class RequestedAsset: Entity
    {
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        public int UserId { get; set; }
    
        public DateTime AcceptedAt { get; set; }

        public DateTime DeniedAt { get; set; }

        [Display(Name ="Note")]
        public string Note { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
