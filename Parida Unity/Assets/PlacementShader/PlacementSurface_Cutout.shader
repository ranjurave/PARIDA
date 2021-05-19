Shader "AR/Placement Surface (Cutout)"
{
    Properties
    {
        _MainTex     ("Texture",      2D)          = "white" {}
        _Color       ("Tint",         Color)       = (1,1,1,1)
        _AlphaCutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "Render Queue" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv     : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4    _MainTex_ST;
            float4    _Color;
            float     _AlphaCutoff;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex  = UnityObjectToClipPos(v.vertex);
                float3 wp = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.uv      = TRANSFORM_TEX(wp.xz, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, fmod(i.uv, 1));
                col *= _Color;
                clip(col.a - _AlphaCutoff);
                return col;
            }

            ENDCG
        }
    }
}
