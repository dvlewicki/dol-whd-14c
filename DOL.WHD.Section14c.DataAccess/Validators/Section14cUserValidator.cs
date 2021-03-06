﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOL.WHD.Section14c.Domain.Models;
using Microsoft.AspNet.Identity;

namespace DOL.WHD.Section14c.DataAccess.Validators
{
    public class Section14cUserValidator<TUser> : UserValidator<TUser, string>
        where TUser : ApplicationUser
    {
        private readonly UserManager<TUser, string> _manager;

        public bool RequireUniqueEINAdmin { get; set; }

        public Section14cUserValidator(UserManager<TUser, string> manager) : base(manager)
        {
            this._manager = manager;
        }

        public override async Task<IdentityResult> ValidateAsync(TUser item)
        {
            IdentityResult result = await base.ValidateAsync(item);

            if (RequireUniqueEINAdmin)
            {
                var errors = new List<string>(result.Errors);

                // check EIN (no more than one admin per EIN)
                var adminEINs = item.Organizations.Where(o => o.IsAdmin).Select(o => o.EIN);
                var match = _manager.Users.Any(u => u.Id != item.Id && u.Organizations.Where(o => o.IsAdmin).Any(o => adminEINs.Contains(o.EIN)));

                if (match)
                {
                    errors.Add("EIN is already registered");
                }

                result = errors.Count <= 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
            }

            return result;
        }
    }
}