using UnityEngine;
using UnityEngine.UI;

public Camera _camera;                    // カメラの背景色用
public Text _text;                        // テキストの文字色用

float c_r = 1.0f, c_g = 0.0f, c_b = 0.0f; // c_r = 赤, c_g = 緑, c_b = 青
float color_speed = 0.02f;                // 色が変わる速さ（0.00f～1.00f）
int c_r_ID = 1, c_g_ID = 0, c_b_ID = 0;   // ID = フラグ処理(１つにまとめても良かった気がするが、わかりやすく個別に）

void Update()
{
    color_change();                       // Updateから読み込み
}

void color_change()
{
    if (c_r_ID == 1 && c_g_ID == 0 && c_b_ID == 0)  //赤→桃
    {
        c_b = c_b + color_speed;                    //青に指定した数を足していく
        if (c_b >= 1.0f)
        {
            c_b_ID = 1;                             //1.0f入れ終わったらフラグを立て次の処理へ
        }
    }
    else if (c_r_ID == 1 && c_g_ID == 0 && c_b_ID == 1) //桃→青
    {
        c_r = c_r - color_speed;
        if (c_r <= 0.0f)
        {
            c_r_ID = 0;
        }
    }
    else if (c_r_ID == 0 && c_g_ID == 0 && c_b_ID == 1) //青→水色
    {
        c_g = c_g + color_speed;
        if (c_g >= 1.0f)
        {
            c_g_ID = 1;
        }
    }
    else if (c_r_ID == 0 && c_g_ID == 1 && c_b_ID == 1) //水色→緑
    {
        c_b = c_b - color_speed;
        if (c_b <= 0.0f)
        {
            c_b_ID = 0;
        }
    }
    else if (c_r_ID == 0 && c_g_ID == 1 && c_b_ID == 0) //緑→黄色
    {
        c_r = c_r + color_speed;
        if (c_r >= 1.0f)
        {
            c_r_ID = 1;
        }
    }
    else if (c_r_ID == 1 && c_g_ID == 1 && c_b_ID == 0)
    {
        c_g = c_g - color_speed;
        if (c_g <= 0.0f)
        {
            c_g_ID = 0;
        }
    }
    _camera.backgroundColor = new Color(c_r, c_g, c_b, 1.0f); // 背景色の指定（最後の1.0fは透明度なので省いてもOK）
    _text.color = new Color(c_r, c_g, c_b, 1.0f);             // 文字色
}
