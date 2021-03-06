/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BLOCKJUMP = 3710956116U;
        static const AkUniqueID BLOCKSLIDE = 764666183U;
        static const AkUniqueID BLOCKWALL = 3327154252U;
        static const AkUniqueID CLICK = 1584507803U;
        static const AkUniqueID COUNTDOWN = 1505888634U;
        static const AkUniqueID DAMAGE = 1786804762U;
        static const AkUniqueID DEATHGLITCH = 2498214274U;
        static const AkUniqueID DECOSOUNDS = 4009259254U;
        static const AkUniqueID JUMP = 3833651337U;
        static const AkUniqueID JUMP_END = 2752223339U;
        static const AkUniqueID KEY1EVENT = 1896912949U;
        static const AkUniqueID KEY2EVENT = 3857418364U;
        static const AkUniqueID KEY3EVENT = 2980983199U;
        static const AkUniqueID KEY4EVENT = 2025595638U;
        static const AkUniqueID LANESWITCH = 699052971U;
        static const AkUniqueID MENUAPPEAR = 918314131U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID PAUSEGAME = 1589270263U;
        static const AkUniqueID POPUP_SPAWN = 416742853U;
        static const AkUniqueID QUITTING = 4172439308U;
        static const AkUniqueID RESUMEGAME = 1133184122U;
        static const AkUniqueID RUN = 712161704U;
        static const AkUniqueID SLIDE = 3686556480U;
        static const AkUniqueID STARTGAME = 1521187885U;
        static const AkUniqueID WARNING = 2176025603U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAMESTATE
        {
            static const AkUniqueID GROUP = 4091656514U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PAUSED = 319258907U;
            } // namespace STATE
        } // namespace GAMESTATE

        namespace KEY
        {
            static const AkUniqueID GROUP = 1183067778U;

            namespace STATE
            {
                static const AkUniqueID KEY_1 = 3865414090U;
                static const AkUniqueID KEY_2 = 3865414089U;
                static const AkUniqueID KEY_3 = 3865414088U;
                static const AkUniqueID KEY_4 = 3865414095U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace KEY

        namespace SLIDE
        {
            static const AkUniqueID GROUP = 3686556480U;

            namespace STATE
            {
                static const AkUniqueID JUMPING = 68157183U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID RUNNING = 3863236874U;
                static const AkUniqueID SLIDING = 472853913U;
            } // namespace STATE
        } // namespace SLIDE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace KEY
        {
            static const AkUniqueID GROUP = 1183067778U;

            namespace SWITCH
            {
                static const AkUniqueID KEY_1 = 3865414090U;
                static const AkUniqueID KEY_2 = 3865414089U;
                static const AkUniqueID KEY_3 = 3865414088U;
                static const AkUniqueID KEY_4 = 3865414095U;
            } // namespace SWITCH
        } // namespace KEY

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID MAIN_VOLUME = 2312172015U;
        static const AkUniqueID MUSIC_VOLUME = 1006694123U;
        static const AkUniqueID SFX_VOLUME = 1564184899U;
        static const AkUniqueID SPEED = 640949982U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID BLOCKJUMP = 3710956116U;
        static const AkUniqueID JUMP = 3833651337U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
