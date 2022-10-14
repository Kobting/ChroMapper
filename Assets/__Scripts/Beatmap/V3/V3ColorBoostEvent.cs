using System;
using Beatmap.Base;
using SimpleJSON;
using UnityEngine;

namespace Beatmap.V3
{
    public class V3ColorBoostEvent : BaseColorBoostEvent
    {
        public V3ColorBoostEvent()
        {
        }

        public V3ColorBoostEvent(BaseColorBoostEvent other) : base(other)
        {
        }

        public V3ColorBoostEvent(BaseEvent evt) : base(evt)
        {
        }

        public V3ColorBoostEvent(JSONNode node)
        {
            Time = RetrieveRequiredNode(node, "b").AsFloat;
            Toggle = RetrieveRequiredNode(node, "o").AsBool;
            CustomData = node["customData"];
        }

        public V3ColorBoostEvent(float time, bool toggle, JSONNode customData = null) : base(time, toggle, customData)
        {
        }

        public override Color? CustomColor
        {
            get => null;
            set { }
        }

        public override string CustomKeyTrack { get; } = "track";
        
        public override string CustomKeyColor { get; } = "color";

        public override string CustomKeyPropID { get; } = "propID";

        public override string CustomKeyLightID { get; } = "lightID";

        public override string CustomKeyLerpType { get; } = "lerpType";

        public override string CustomKeyEasing { get; } = "easing";

        public override string CustomKeyLightGradient { get; } = "lightGradient";

        public override string CustomKeyStep { get; } = "step";

        public override string CustomKeyProp { get; } = "prop";

        public override string CustomKeySpeed { get; } = "speed";

        public override string CustomKeyStepMult { get; } = "stepMult";

        public override string CustomKeyPropMult { get; } = "propMult";

        public override string CustomKeySpeedMult { get; } = "speedMult";

        public override string CustomKeyPreciseSpeed { get; } = "preciseSpeed";

        public override string CustomKeyDirection { get; } = "direction";

        public override string CustomKeyLockRotation { get; } = "lockRotation";

        public override string CustomKeyLaneRotation { get; } = "rotation";

        public override string CustomKeyNameFilter { get; } = "nameFilter";

        public override bool IsPropagation { get; } = false;

        public override JSONNode ToJson()
        {
            JSONNode node = new JSONObject();
            node["b"] = Math.Round(Time, DecimalPrecision);
            node["o"] = Toggle;
            CustomData = SaveCustom();
            if (CustomData.Count == 0) return node;
            node["customData"] = CustomData;
            return node;
        }

        public override BaseItem Clone() => new V3ColorBoostEvent(Time, Toggle, CustomData?.Clone());
    }
}
