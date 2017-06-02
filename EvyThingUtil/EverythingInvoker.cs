using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EvyThingUtil
{
    class EverythingInvoker
    {
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)] // frees the old search and allocates the new search string.
        public static extern int Everything_SetSearchW(string lpSearchString);
        [DllImport("Everything64.dll")]
        public static extern void Everything_SetMatchPath(bool bEnable);
        [DllImport("Everything64.dll")]
        public static extern void Everything_SetMatchCase(bool bEnable);
        [DllImport("Everything64.dll")]
        public static extern void Everything_SetMatchWholeWord(bool bEnable);
        [DllImport("Everything64.dll")]
        public static extern void Everything_SetRegex(bool bEnable);
        [DllImport("Everything64.dll")]
        public static extern void Everything_SetMax(int dwMax);
        [DllImport("Everything64.dll")]
        public static extern void Everything_SetOffset(int dwOffset);
        [DllImport("Everything64.dll")]
        public static extern void Everything_SetSort(int dwSort);

        [DllImport("Everything64.dll")]
        public static extern bool Everything_GetMatchPath();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_GetMatchCase();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_GetMatchWholeWord();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_GetRegex();
        [DllImport("Everything64.dll")]
        public static extern UInt32 Everything_GetMax();
        [DllImport("Everything64.dll")]
        public static extern UInt32 Everything_GetOffset();
        [DllImport("Everything64.dll")]
        public static extern string Everything_GetSearchW();
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetLastError();
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetSort();

        [DllImport("Everything64.dll")] // frees the old result list and allocates the new result list.
        public static extern bool Everything_QueryW(bool bWait);

        [DllImport("Everything64.dll")]
        public static extern void Everything_SortResultsByPath();

        /*
         * Use Everything_GetTotFileResults to retrieve the total number of file results.
         *If the result offset state is 0, and the max result is 0xFFFFFFFF, Everything_GetNumFileResults
         *will return the total number of file results and all file results will be visible.
         */
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetNumFileResults();
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetNumFolderResults();
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetNumResults();
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetTotFileResults();
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetTotFolderResults();
        [DllImport("Everything64.dll")]
        public static extern int Everything_GetTotResults();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_IsVolumeResult(int nIndex);
        [DllImport("Everything64.dll")]
        public static extern bool Everything_IsFolderResult(int nIndex);
        [DllImport("Everything64.dll")]
        public static extern bool Everything_IsFileResult(int nIndex);
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        public static extern void Everything_GetResultFullPathNameW(int nIndex, StringBuilder lpString, int nMaxCount);


        [DllImport("Everything64.dll")] //frees the current search and current result list.
        public static extern void Everything_Reset();

        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        public static extern StringBuilder Everything_GetResultFileNameW(int nIndex);
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        public static extern StringBuilder Everything_GetResultPathW(int nIndex);
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultExtensionW(int nIndex);
        [DllImport("Everything64.dll")]
        public static extern bool Everything_GetResultSize(int nIndex, ref int lpSize);
        [DllImport("Everything64.dll")]
        public static extern bool Everything_GetResultDateModified(int nIndex, ref int[] lpDateModified);
        
        [DllImport("Everything64.dll")]
        public static extern bool Everything_IsDBLoaded();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_IsAdmin();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_IsAppData();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_SaveDB();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_RebuildDB();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_UpdateAllFolderIndexes();
        [DllImport("Everything64.dll")]
        public static extern bool Everything_SaveRunHistory();
        [DllImport("Everything64.dll")] // free any memory allocated by the Everything SDK.
        public static extern bool Everything_CleanUp();
    }
}
