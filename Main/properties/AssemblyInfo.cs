using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle( "Universalis" )]
[assembly: AssemblyDescription( "Build groups and whole universes for Universalis." )]

// Die folgende GUID bestimmt die ID der Typbibliothek, wenn dieses Projekt für COM verfügbar gemacht wird
[assembly: Guid( "16d00bb9-3021-4643-88e8-15794240cab2" )]

[assembly: AssemblyCompany( "" )]
[assembly: AssemblyProduct( "Universalis Builder" )]

[assembly: AssemblyCopyright( "Copyright © Markus Lobedann 2024" )]
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