using System;
using System.Threading;

namespace VerifyArgs.Util
{
	/// <summary>
	/// Helpers for <see cref="ReaderWriterLockSlim" />.
	/// </summary>
	internal static class ReaderWriterLockSlimUtil
	{
		#region IDisposable helpers

		private sealed class ReadScope : IDisposable
		{
			private readonly ReaderWriterLockSlim _rwLock;

			public ReadScope(ReaderWriterLockSlim rwLock)
			{
				_rwLock = rwLock;
				_rwLock.EnterReadLock();
			}

			public void Dispose()
			{
				_rwLock.ExitReadLock();
			}
		}

		private sealed class WriteScope : IDisposable
		{
			private readonly ReaderWriterLockSlim _rwLock;

			public WriteScope(ReaderWriterLockSlim rwLock)
			{
				_rwLock = rwLock;
				_rwLock.EnterWriteLock();
			}

			public void Dispose()
			{
				_rwLock.ExitWriteLock();
			}
		}

		#endregion

		/// <summary>
		/// Creates read scope for given reader/writer lock.
		/// </summary>
		/// <param name="rwLock">Reader/writer lock.</param>
		/// <returns>Read scope object.</returns>
		public static IDisposable ReadLock(this ReaderWriterLockSlim rwLock)
		{
			return new ReadScope(rwLock);
		}

		/// <summary>
		/// Creates write scope for given reader/writer lock.
		/// </summary>
		/// <param name="rwLock">Reader/writer lock.</param>
		/// <returns>Write scope object.</returns>
		public static IDisposable WriteLock(this ReaderWriterLockSlim rwLock)
		{
			return new WriteScope(rwLock);
		}
	}
}
