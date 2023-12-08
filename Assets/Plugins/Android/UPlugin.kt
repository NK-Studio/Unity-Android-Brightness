package com.unity3d.player

import android.app.AlertDialog
import android.content.DialogInterface
import android.content.Intent
import android.net.Uri
import android.provider.Settings
import android.util.Log
import android.widget.Toast
import com.unity3d.player.UnityPlayer
import com.unity3d.player.UnityPlayerActivity

class UPlugin : UnityPlayerActivity()
{
    private fun SetBrightness(adjustedBrightness: Int) {

        val canWrite = Settings.System.canWrite(UnityPlayer.currentActivity)

        if (canWrite)
        {
            Settings.System.putInt(
                UnityPlayer.currentActivity.contentResolver,
                Settings.System.SCREEN_BRIGHTNESS,
                adjustedBrightness
            )
        }
    }

    private fun GetBrightness(): Int {
        // 현재 화면 밝기 가져오기
        val currentBrightness: Int = Settings.System.getInt(
            UnityPlayer.currentActivity.contentResolver,
            Settings.System.SCREEN_BRIGHTNESS
        )

        return currentBrightness;
    }
    
    private fun AskPermission() {
        // 권한 요청
        val intent = Intent(Settings.ACTION_MANAGE_WRITE_SETTINGS)
        intent.data = Uri.parse("package:$packageName")
        UnityPlayer.currentActivity.startActivity(intent)
    }
}