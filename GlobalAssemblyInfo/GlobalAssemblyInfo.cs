using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// global information for every one of our assemblies

[assembly: AssemblyCompany( "" )]
[assembly: AssemblyProduct( "Universalis Program Suite" )]

[assembly: AssemblyCopyright( "Copyright © Markus Lobedann 2022" )]
[assembly: AssemblyTrademark( "" )]

[assembly: AssemblyCulture( "" )]

[assembly: ComVisible( false )]

#if DEBUG
    [assembly: AssemblyConfiguration( "Debug" )]
#else
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion( "0.7.0.0" )]
[assembly: NeutralResourcesLanguage( "de-DE" )]