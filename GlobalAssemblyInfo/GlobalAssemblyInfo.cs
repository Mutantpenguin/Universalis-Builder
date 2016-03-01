using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// global information for every one of our assemblies

[assembly: AssemblyCompany( "" )]
[assembly: AssemblyProduct( "Tesserakt Program Suite" )]

[assembly: AssemblyCopyright( "Copyright © Markus Lobedann 2015" )]
[assembly: AssemblyTrademark( "" )]

[assembly: AssemblyCulture( "" )]

[assembly: ComVisible( false )]

#if DEBUG
    [assembly: AssemblyConfiguration( "Debug" )]
#else
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion( "0.9.*" )]
[assembly: NeutralResourcesLanguage( "de-DE" )]