using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.IDto;

namespace Udemy.AdvertisementApp.Core.Dtos.AppRoleDtos
{
	public class AppRoleListDto:IDTO
	{
		public int Id { get; set; }
		public string RoleName { get; set; }
	}
}
