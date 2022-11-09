using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace Anargo
{

    //[Category("✫ Blackboard")]
    [Description("Check whether or not a variable is null")]
    public class CheckItem : ConditionTask
    {

        [BlackboardOnly]
        public BBParameter<ItemScriptables> variableA;
        public BBParameter<ItemScriptables> variableB;

        protected override string info {
            get { return variableA + " == " + variableB; }
        }

        protected override bool OnCheck() {
            return variableA.value == variableB.value;
        }
    }
}