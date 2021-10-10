using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SearchFilter
    {
        public string TextToSearch { get; init; }

        public int Skip { get; init; }
        public int Take { get; init; }

        public IReadOnlyCollection<string> Interests { get; set; }


        [DataType(DataType.Date)]
        public DateTime? StartDate { get; init; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; init; }
    }
}
