// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,cmtg:SF,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,acwp:False,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7241-RGB,custl-6452-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32169,y:32780,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8,c2:0,c3:0.1,c4:1;n:type:ShaderForge.SFN_LightVector,id:8252,x:30124,y:32824,varname:node_8252,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:6206,x:30124,y:32969,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:221,x:30338,y:32824,varname:node_221,prsc:2,dt:1|A-8252-OUT,B-6206-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:5229,x:30338,y:32979,varname:node_5229,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4549,x:30553,y:32824,varname:node_4549,prsc:2|A-221-OUT,B-5229-OUT;n:type:ShaderForge.SFN_Set,id:8940,x:30748,y:32710,varname:ShadowData,prsc:2|IN-4549-OUT;n:type:ShaderForge.SFN_LightColor,id:4539,x:30553,y:32979,varname:node_4539,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3460,x:30769,y:32824,varname:node_3460,prsc:2|A-4549-OUT,B-4539-RGB;n:type:ShaderForge.SFN_Set,id:2137,x:31002,y:32824,varname:LightData,prsc:2|IN-3460-OUT;n:type:ShaderForge.SFN_Get,id:4346,x:32169,y:32976,varname:node_4346,prsc:2|IN-2137-OUT;n:type:ShaderForge.SFN_NormalVector,id:959,x:29975,y:33318,prsc:2,pt:False;n:type:ShaderForge.SFN_HalfVector,id:4667,x:29975,y:33477,varname:node_4667,prsc:2;n:type:ShaderForge.SFN_Dot,id:9166,x:30266,y:33320,varname:node_9166,prsc:2,dt:1|A-959-OUT,B-4667-OUT;n:type:ShaderForge.SFN_Slider,id:7765,x:30109,y:33538,ptovrint:False,ptlb:SpecularPower,ptin:_SpecularPower,varname:node_7765,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.752571,max:10;n:type:ShaderForge.SFN_Power,id:2577,x:30485,y:33320,varname:node_2577,prsc:2|VAL-9166-OUT,EXP-1180-OUT;n:type:ShaderForge.SFN_Exp,id:1180,x:30485,y:33493,varname:node_1180,prsc:2,et:0|IN-7765-OUT;n:type:ShaderForge.SFN_Slider,id:1187,x:30600,y:33568,ptovrint:False,ptlb:SpecularIntensity,ptin:_SpecularIntensity,varname:node_1187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5852803,max:10;n:type:ShaderForge.SFN_Multiply,id:2876,x:30736,y:33320,varname:node_2876,prsc:2|A-8190-RGB,B-2577-OUT,C-1187-OUT,D-7487-OUT;n:type:ShaderForge.SFN_Color,id:8190,x:30626,y:33163,ptovrint:False,ptlb:SpecularColor,ptin:_SpecularColor,varname:node_8190,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Get,id:7487,x:30736,y:33445,varname:node_7487,prsc:2|IN-8940-OUT;n:type:ShaderForge.SFN_Set,id:4228,x:31007,y:33317,varname:SpecularData,prsc:2|IN-2876-OUT;n:type:ShaderForge.SFN_Add,id:6452,x:32429,y:32962,varname:node_6452,prsc:2|A-4346-OUT,B-7689-OUT;n:type:ShaderForge.SFN_Get,id:7689,x:32163,y:33073,varname:node_7689,prsc:2|IN-4228-OUT;proporder:7241-7765-1187-8190;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _Color ("Color", Color) = (0.8,0,0.1,1)
        _SpecularPower ("SpecularPower", Range(0, 10)) = 2.752571
        _SpecularIntensity ("SpecularIntensity", Range(0, 10)) = 0.5852803
        _SpecularColor ("SpecularColor", Color) = (1,1,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
            "CustomTag"="SF"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #if !UNITY_PASS_FORWARDBASE
            #define UNITY_PASS_FORWARDBASE
            #endif
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _SpecularPower;
            uniform float _SpecularIntensity;
            uniform float4 _SpecularColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
////// Emissive:
                float3 emissive = _Color.rgb;
                float node_4549 = (max(0,dot(lightDirection,i.normalDir))*attenuation);
                float3 LightData = (node_4549*_LightColor0.rgb);
                float ShadowData = node_4549;
                float3 SpecularData = (_SpecularColor.rgb*pow(max(0,dot(i.normalDir,halfDirection)),exp(_SpecularPower))*_SpecularIntensity*ShadowData);
                float3 finalColor = emissive + (LightData+SpecularData);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #if !UNITY_PASS_FORWARDADD
            #define UNITY_PASS_FORWARDADD
            #endif
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _SpecularPower;
            uniform float _SpecularIntensity;
            uniform float4 _SpecularColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float node_4549 = (max(0,dot(lightDirection,i.normalDir))*attenuation);
                float3 LightData = (node_4549*_LightColor0.rgb);
                float ShadowData = node_4549;
                float3 SpecularData = (_SpecularColor.rgb*pow(max(0,dot(i.normalDir,halfDirection)),exp(_SpecularPower))*_SpecularIntensity*ShadowData);
                float3 finalColor = (LightData+SpecularData);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
