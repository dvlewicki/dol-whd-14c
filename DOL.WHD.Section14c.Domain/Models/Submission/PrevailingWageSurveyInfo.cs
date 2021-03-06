﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DOL.WHD.Section14c.Domain.Models.Submission
{
    public class PrevailingWageSurveyInfo
    {
        public int Id { get; set; }

        [Required]
        public string BasedOnSurvey { get; set; }

        [Required]
        public virtual ICollection<SourceEmployer> SourceEmployers { get; set; }

        // TODO: Prevailing Wage Determination - Hourly upload
    }
}
