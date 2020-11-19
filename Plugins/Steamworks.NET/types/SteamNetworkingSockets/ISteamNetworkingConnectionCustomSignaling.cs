// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2019 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || STEAMWORKS_WIN || STEAMWORKS_LIN_OSX)
	#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks
{
	/// Interface used to send signaling messages for a particular connection.
	/// You will need to construct one of these per connection.
	///
	/// - For connections initiated locally, you will construct it and pass
	///   it to ISteamNetworkingSockets::ConnectP2PCustomSignaling.
	/// - For connections initiated remotely and "accepted" locally, you
	///   will return it from ISteamNetworkingCustomSignalingRecvContext::OnConnectRequest
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct ISteamNetworkingConnectionCustomSignaling
	{
		/// Called to send a rendezvous message to the remote peer.  This may be called
		/// from any thread, at any time, so you need to be thread-safe!  Don't take
		/// any locks that might hold while calling into SteamNetworkingSockets functions,
		/// because this could lead to deadlocks.
		///
		/// Note that when initiating a connection, we may not know the identity
		/// of the peer, if you did not specify it in ConnectP2PCustomSignaling.
		///
		/// Return true if a best-effort attempt was made to deliver the message.
		/// If you return false, it is assumed that the situation is fatal;
		/// the connection will be closed, and Release() will be called
		/// eventually.
		///
		/// Signaling objects will not be shared between connections.
		/// You can assume that the same value of hConn will be used
		/// every time.
		public bool SendSignal(HSteamNetConnection hConn, ref SteamNetConnectionInfo_t info, IntPtr pMsg, int cbMsg) {
			return NativeMethods.SteamAPI_ISteamNetworkingConnectionCustomSignaling_SendSignal(ref this, hConn, ref info, pMsg, cbMsg);
		}

		/// Called when the connection no longer needs to send signals.
		/// Note that this happens eventually (but not immediately) after
		/// the connection is closed.  Signals may need to be sent for a brief
		/// time after the connection is closed, to clean up the connection.
		public void Release() {
			NativeMethods.SteamAPI_ISteamNetworkingConnectionCustomSignaling_Release(ref this);
		}
	}
}

#endif // !DISABLESTEAMWORKS