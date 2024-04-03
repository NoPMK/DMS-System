using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ServiceInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.Operations;
using DMS_GUI.Helpers.Calculators.Interfaces;
using DMS_GUI.Helpers.Mappers.Interfaces;
using DMS_GUI.Services.EventHandlerServices;
using DMS_GUI.States;

namespace DMS_GUI
{
    public partial class BusDMS : Form
    {
        private readonly ISetupService _setupService;
        private readonly IFormatter _formatter;
        private readonly IFileOperationsWrapper _fileOperations;
        private readonly IFolderOperationsWrapper _folderOperations;
        private readonly ITextHandler _textHandler;
        private readonly IErrorHandler _errorHandler;
        private readonly ICalculator _calculator;
        private readonly IFileSystemValidator _fileSystemValidator;
        private readonly IAppLogger _logger;
        private readonly IControlItemConverter _controlItemConverter;
        private readonly ITreeNodeService _treeNodeService;
        private readonly OperationsEvents _operationsEvents;

        public FormState State { get; } = new FormState();

        public BusDMS(ISetupService setupService,
                     IFormatter formatter,
                     ITextHandler textHandler,
                     IErrorHandler errorHandler,
                     IFileOperationsWrapper fileOperations,
                     IFolderOperationsWrapper folderOperations,
                     ICalculator calculator,
                     IFileSystemValidator directoryValidator,
                     IAppLogger appLogger,
                     IControlItemConverter controlItemConverter,
                     ITreeNodeService treeNodeService)
        {
            _setupService = setupService ?? throw new ArgumentNullException(nameof(setupService));
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            _textHandler = textHandler ?? throw new ArgumentNullException(nameof(textHandler));
            _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));
            _folderOperations = folderOperations ?? throw new ArgumentNullException(nameof(folderOperations));
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _fileSystemValidator = directoryValidator ?? throw new ArgumentNullException(nameof(directoryValidator));
            _logger = appLogger ?? throw new ArgumentNullException(nameof(appLogger));
            _controlItemConverter = controlItemConverter ?? throw new ArgumentNullException(nameof(controlItemConverter));
            _treeNodeService = treeNodeService ?? throw new ArgumentNullException(nameof(treeNodeService));
            _operationsEvents = new OperationsEvents(this, _logger);

            InitializeComponent();
            InitializeForm();
        }

        //Setup
        private void InitializeForm()
        {
            SetupLogger();
            SetupUI();
            SetupEventHandlers();
            SetTheme();
        }

        private void SetupListViewContextMenu()
        {
            RightList.ContextMenuStrip = RightClickMenu;
            LeftList.ContextMenuStrip = RightClickMenu;
        }

        private void QueryStructureTrees()
        {
            GetStructureTree(LeftPanelComboBox, LeftPanelStructure);
            GetStructureTree(RightPanelComboBox, RightPanelStructure);
        }

        private void QueryDrives()
        {
            PopulateDriveComboBox(LeftPanelComboBox);
            PopulateDriveComboBox(RightPanelComboBox);

            DisplayInitialFolderContents(LeftPanelComboBox, LeftList);
            DisplayInitialFolderContents(RightPanelComboBox, RightList);
        }

        private void SetupUI()
        {
            QueryDrives();
            QueryStructureTrees();
            SetupListViewContextMenu();
        }

        private void SetupLogger()
        {
            _logger.MessageLogged += Logger_MessageLogged;
        }

        private void SetupEventHandlers()
        {
            _fileOperations.Subscribe(_operationsEvents);
            _folderOperations.Subscribe(_operationsEvents);
        }

        private void SetTheme()
        {
            SetExplorerTheme();
            SwitchToDarkTheme();
        }
    }
}