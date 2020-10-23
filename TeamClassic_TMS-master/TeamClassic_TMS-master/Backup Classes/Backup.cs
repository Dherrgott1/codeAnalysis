using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{
    /// \class Backup
    /// 
    /// \brief This class is used to backup data in the TMS system.
    /// 
    /// This class provides methods for creating a backup of the local
    /// TMS Database.
    ///
    public class Backup
    {
        public string backupLocation_m; //!< The location where the backup files are being stored


        ///
        /// \brief This method is the constructor the Backup class
        /// 
        /// \details <b>Details</b>
        ///     This constructor takes a single parameter: <i>string location</i>.
        ///     This parameter represents the location on the file system that
        ///     the backup files are being stored in.
        ///
        /// \param location - <b>string</b> - The location on the file system where
        ///     the backup is being stored
        /// 
        /// \return This method is a constructor, and therefore does not return anything
        ///
        public Backup(string location)
        {
            this.backupLocation_m = location;
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref backupLocation_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref backupLocation_m</i>
        /// data member. It allows getting the value of <i>string \ref backupLocation_m</i>,
        /// and setting the value of <i>string \ref backupLocation_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref backupLocation_m</i>.
        /// 
        /// \return backupLocation_m - <b>string</b> - The value of <i>string \ref backupLocation_m</i>.
        ///
        public string BackupLocation
        {
            get { return this.backupLocation_m; }

            set
            {
                this.backupLocation_m = value;
            }
        }


        ///
        /// \brief Generates a backup of the TMS database
        /// 
        /// \details <b>Details</b>
        ///     This function performs a backup job on the
        ///     local TMS Database. A bool is returned which
        ///     indicates whether the backup was successful or not.
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return backupStatus - <b>bool</b> - true if the database backup was 
        ///     successful and false if it wasn't
        ///
        bool GenerateBackup()
        {
            bool backupStatus = false;

            return backupStatus;
        }
    }
}
