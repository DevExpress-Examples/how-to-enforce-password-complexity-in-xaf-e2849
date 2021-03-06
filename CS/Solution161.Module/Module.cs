using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using System.Reflection;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Security;
using System.Text.RegularExpressions;
using DevExpress.ExpressApp.Validation;


namespace Solution161.Module {
    public sealed partial class Solution161Module : ModuleBase {
        public Solution161Module() {
            InitializeComponent();
        }
        public override void Setup(ApplicationModulesManager moduleManager) {
            base.Setup(moduleManager);
            ValidationRulesRegistrator.RegisterRule(moduleManager, 
                typeof(PasswordStrengthCodeRule),
                typeof(IRuleBaseProperties));
        }
        public override void Setup(XafApplication application) {
            application.SetupComplete += new EventHandler<EventArgs>(application_SetupComplete);
            base.Setup(application);
        }
        //this code is necessary to enable validation in the "Change Password On First Logon" window.
        void application_SetupComplete(object sender, EventArgs e) {
            ValidationModule module = (ValidationModule)((XafApplication)sender).Modules.FindModule(typeof(ValidationModule));
            if (module != null) {
                module.InitializeRuleSet();
            }
        }
    }

    [CodeRule]
    public class PasswordStrengthCodeRule : RuleBase<ChangePasswordOnLogonParameters> {
        public PasswordStrengthCodeRule()
            : base("", "ChangePassword") {
            this.Properties.SkipNullOrEmptyValues = false;
        }
        public PasswordStrengthCodeRule(IRuleBaseProperties properties) : base(properties) { }
        protected override bool IsValidInternal(ChangePasswordOnLogonParameters target, out string errorMessageTemplate) {
            if (CalculatePasswordStrength(target.NewPassword) < 3) {
                errorMessageTemplate = "password strength is insufficient";
                return false;
            }
            errorMessageTemplate = string.Empty;
            return true;
        }
        private int CalculatePasswordStrength(string pwd) {
            int weight = 0;
            if (pwd == null) return weight; 
            if (pwd.Length > 1 && pwd.Length < 4)
                ++weight;
            else {
                if (pwd.Length > 5)
                    ++weight;
                Regex rxUpperCase = new Regex("[A-Z]");
                Regex rxLowerCase = new Regex("[a-z]");
                Regex rxNumerals = new Regex("[0-9]");
                Match match = rxUpperCase.Match(pwd);
                if (match.Success)
                    ++weight;
                match = rxLowerCase.Match(pwd);
                if (match.Success)
                    ++weight;
                match = rxNumerals.Match(pwd);
                if (match.Success)
                    ++weight;
            }
            if (weight == 3 && pwd.Length < 6)
                --weight;
            if (weight == 4 && pwd.Length > 10)
                ++weight;
            return weight;
        }
    }

 

}
