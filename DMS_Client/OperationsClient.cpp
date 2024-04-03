#include "Precompiled.h"
#include "ComService.h"
#include "UserInterfaceService.h"
#include "FileOperationService.h"
#include <iostream>
#include <string>
#include <memory>

int main() {
	try {
		ComService comService;
		comService.InitializeServices();

		if (comService.IsInitialized()) {
			comService.RunUserInterface();
		}
		else {
			std::cerr << "Initialization failed." << std::endl;
		}
	}
	catch (const std::exception& e) {
		std::cerr << "An error occurred: " << e.what() << std::endl;
		return -1;
	}

	return 0;
}