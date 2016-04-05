using System;
namespace Android
{
	public interface IAppInfoService
	{
		int CodeVersion { get; }

		string VersionName { get; }
	}

}

