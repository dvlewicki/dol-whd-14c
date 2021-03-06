﻿using System.Collections.Generic;
using DOL.WHD.Section14c.Domain.Models;

namespace DOL.WHD.Section14c.Domain.ViewModels
{
    // Models returned by AccountController actions.
    public class UserInfoViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public IEnumerable<OrganizationMembership> Organizations { get; set; }
    }
}
