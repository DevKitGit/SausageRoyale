Shader "Unlit/StripesShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color1("Color 1", Color) = (0,0,0,1)
		_Color2("Color 2", Color) = (1,1,1,1)
		_Tiling("Tiling", Range(1, 500)) = 10
		_Direction("Direction", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

			fixed4 _Color1;
			fixed4 _Color2;
            sampler2D _MainTex;
            float4 _MainTex_ST;
			int _Tiling;
			float _Direction;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

			fixed4 frag(v2f i) : SV_Target
			{
				float pos = lerp(i.uv.x, i.uv.y, _Direction) * _Tiling;
				fixed value = floor(frac(pos) + 0.5);
				return lerp(_Color1, _Color2, value);
			}
            ENDCG
        }
    }
}
