using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
	public interface IRegionAggregate
	{
		IEnumerable<RegionResponse> GetAll();
		RegionResponse Find(string regionCode);
	}
}