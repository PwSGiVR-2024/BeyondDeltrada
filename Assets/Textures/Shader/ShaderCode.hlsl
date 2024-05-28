void MainLight_float(float3 WorldPos, out float3 Direction, out float3 Color, out float DistaneAtten, out float ShadowAtten)
{
    #ifdef SHADERGRAPH_PREVIEW
        Direction = normalize(float3(0.5f, 0.5f, 0.25f));
        Color = float3(1.0f, 1.0f, 1.0f);
        DistaneAtten = 1.0f;
        ShadowAtten = 1.0f;

    #else
        float4 shadowCoord = TransformWorldToShadowCoord(WroldPos);
        Light mainLight = GetMainLight(shadowCoord);

        Direction = mainLight.direction;
        Color = mainLight.color;
        DistanceAtten = mainLight.distanceAttenuation;
        ShadowAtten = mainLight.shadowAttenuartion;
    #endif
}