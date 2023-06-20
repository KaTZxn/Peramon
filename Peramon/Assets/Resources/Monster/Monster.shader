// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Monster"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _AngleX("AngleX", Range(-180,180)) = 0
        _AngleY("AngleY", Range(-180,180)) = 0

        _DisappearOffset ("Disappear Offset",Range(-0.5,0.5)) = 0.5
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "DisableBatching" = "True"}
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            Cull Off
            Lighting Off

            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag	

			
			#include "UnityCG.cginc"

            

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float3 uv : TEXCOORD0;				
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _AngleX;
            float _AngleY;
            float _DisappearOffset;
            v2f vert (appdata v)
            {
                v2f o;
                if(_AngleX != 0)
                {
                    v.vertex += _AngleX < 0 ? float4(-5, 0, 0, 0) : float4(5, 0, 0, 0);
				
                    float s;
                    float c;
                    sincos(radians(_AngleX), s, c);
                    float4x4 rotate = {
                        c,s,0,0,
                        -s,c,0,0,
                        0,0,1,0,
                        0,0,0,1
                    };

                    v.vertex = mul(rotate, v.vertex);                

                    v.vertex -= _AngleX < 0 ? float4(-5, 0, 0, 0) : float4(5, 0, 0, 0);
                }

                if(_AngleY != 0)
                {
                    v.vertex += _AngleY < 0 ? float4(0, 0, -5, 0) : float4(0, 0, 5, 0);
				
                    float s;
                    float c;
                    sincos(radians(_AngleY), s, c);
                    float4x4 rotate = {
                        1,0,0,0,
                        0,c,-s,0,
                        0,s,c,0,
                        0,0,0,1
                    };

                    
                    v.vertex = mul(rotate, v.vertex);                

                    v.vertex -= _AngleY < 0 ? float4(0, 0, -5, 0) : float4(0, 0, 5, 0);
                }

                o.vertex = UnityObjectToClipPos(v.vertex);
				//o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.z = _DisappearOffset - v.vertex.y;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //コンテンツとページテクスチャ色取得
				float4 col = tex2D(_MainTex, i.uv);
                //背面のカラー
                float4 backcol = tex2D(_MainTex, i.uv);
                //RGB * 0.6
                //Alpha値調整
                //
				return col;
            }

			ENDCG
        }

 

    }
}
