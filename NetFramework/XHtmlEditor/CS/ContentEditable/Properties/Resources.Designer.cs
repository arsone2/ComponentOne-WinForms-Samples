﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContentEditable.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ContentEditable.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; &gt;
        ///&lt;head&gt;
        ///    &lt;title&gt;Untitled Page&lt;/title&gt;
        ///    &lt;style type=&quot;text/css&quot;&gt;
        ///    &lt;/style&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///
        ///    &lt;p&gt;111&lt;/p&gt;
        ///    &lt;p contenteditable=&quot;false&quot; style=&quot;color:gray;&quot;&gt;222&lt;/p&gt;
        ///    &lt;p&gt;333&lt;/p&gt;
        ///    &lt;p&gt;444&lt;/p&gt;
        ///    &lt;div contenteditable=&quot;false&quot; style=&quot;color:gray;&quot;&gt;
        ///        &lt;p&gt;333&lt;/p&gt;
        ///        &lt;p&gt;444&lt;/p&gt;
        ///    &lt;/div&gt;
        ///    &lt;p&gt;555&lt;/p&gt;
        ///&lt;/body&gt;
        ///&lt;/html&gt;
        ///.
        /// </summary>
        internal static string Document {
            get {
                return ResourceManager.GetString("Document", resourceCulture);
            }
        }
    }
}