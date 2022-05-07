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
        static const AkUniqueID DAMAGE = 1786804762U;
        static const AkUniqueID HIHAT = 3437592667U;
        static const AkUniqueID JUMP = 3833651337U;
        static const AkUniqueID JUMP_END = 2752223339U;
        static const AkUniqueID KICK = 2181839183U;
        static const AkUniqueID LANESWITCH = 699052971U;
        static const AkUniqueID RUN = 712161704U;
        static const AkUniqueID SLIDE = 3686556480U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace SLIDE
        {
            static const AkUniqueID GROUP = 3686556480U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID RUNNING = 3863236874U;
                static const AkUniqueID SLIDING = 472853913U;
            } // namespace STATE
        } // namespace SLIDE

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID SPEED = 640949982U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
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
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
