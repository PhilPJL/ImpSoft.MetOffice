﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImpSoft.MetOffice.DataHub.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ImpSoft.MetOffice.DataHub.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: the HTTP request failed with status code={1} and reason=&apos;{2}&apos;..
        /// </summary>
        internal static string HttpRequestFailed {
            get {
                return ResourceManager.GetString("HttpRequestFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Latitude must be in the range [-85, 85]..
        /// </summary>
        internal static string LatitudeError {
            get {
                return ResourceManager.GetString("LatitudeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Longitude must be in the range [-180, 180]..
        /// </summary>
        internal static string LongitudeError {
            get {
                return ResourceManager.GetString("LongitudeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter details not found for key=&apos;{0}&apos;..
        /// </summary>
        internal static string ParameterKeyError {
            get {
                return ResourceManager.GetString("ParameterKeyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameter must not be null or empty..
        /// </summary>
        internal static string ParameterMustNotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ParameterMustNotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;The parameter must not be null or whitespace..
        /// </summary>
        internal static string ParameterMustNotBeNullOrWhitespace {
            get {
                return ResourceManager.GetString("ParameterMustNotBeNullOrWhitespace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only forecasts with a single &apos;Feature&apos; are supported. The forecast contains {0} features..
        /// </summary>
        internal static string SingleFeatureError {
            get {
                return ResourceManager.GetString("SingleFeatureError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only forecasts with a single Parameters collection are supported. The forecast contains {0} Parameters collections..
        /// </summary>
        internal static string SingleParameterCollectionError {
            get {
                return ResourceManager.GetString("SingleParameterCollectionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown method.
        /// </summary>
        internal static string UnknownMethod {
            get {
                return ResourceManager.GetString("UnknownMethod", resourceCulture);
            }
        }
    }
}
