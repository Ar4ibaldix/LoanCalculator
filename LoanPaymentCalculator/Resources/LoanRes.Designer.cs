﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoanPaymentCalculator.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LoanRes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoanRes() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LoanPaymentCalculator.Resources.LoanRes", typeof(LoanRes).Assembly);
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
        ///   Looks up a localized string similar to amount:.
        /// </summary>
        internal static string Amount {
            get {
                return ResourceManager.GetString("Amount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to downpayment:.
        /// </summary>
        internal static string Downpayment {
            get {
                return ResourceManager.GetString("Downpayment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to interest:.
        /// </summary>
        internal static string Interest {
            get {
                return ResourceManager.GetString("Interest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to monthly payment:.
        /// </summary>
        internal static string MonthlyPayment {
            get {
                return ResourceManager.GetString("MonthlyPayment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to term:.
        /// </summary>
        internal static string Term {
            get {
                return ResourceManager.GetString("Term", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to total interest:.
        /// </summary>
        internal static string TotalInterest {
            get {
                return ResourceManager.GetString("TotalInterest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to total payment:.
        /// </summary>
        internal static string TotalPayment {
            get {
                return ResourceManager.GetString("TotalPayment", resourceCulture);
            }
        }
    }
}
