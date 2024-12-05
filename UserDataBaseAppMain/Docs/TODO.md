# Contact Management System - TODO List

## Console Application (Grade G Requirements)

### Models and Data Structure
- [x] Create User/Contact model with:
  - [x] GUID Id (auto-generated)
  - [x] FirstName
  - [x] LastName
  - [x] Email
  - [x] PhoneNumber
  - [x] StreetAddress
  - [x] PostalCode
  - [x] City

### Core Functionality
- [x] Set up Business Class Library
- [x] Implement JSON file handling
  - [x] Save contacts to file
  - [x] Load contacts from file
- [x] Create menu system
  - [x] List all contacts
  - [x] Create new contact
  - [ ] Edit existing contact
  - [ ] Delete contact
  - [x] Exit application

### Testing
- [ ] Create test project
- [ ] Write unit tests for:
  - [ ] Contact creation
  - [ ] Contact validation
  - [ ] File operations (non-mock tests)

## GUI Application (Grade VG Requirements)

### Project Setup
- [ ] Create WPF/MAUI project
- [ ] Set up dependency injection
- [ ] Configure shared class library usage

### User Interface
- [ ] Create main window/navigation
- [ ] Implement views:
  - [ ] Contact list page
  - [ ] Create contact page
  - [ ] Edit contact page (with delete)

### Advanced Features
- [ ] Implement SOLID principles:
  - [x] Single Responsibility (separate services)
  - [ ] Open/Closed (extensible design)
  - [ ] Liskov Substitution
  - [ ] Interface Segregation
  - [ ] Dependency Inversion

### Design Patterns
- [ ] Service Pattern:
  - [x] IFileService
  - [x] IUserService
  - [x ] IValidationService
- [ ] Factory Pattern:
  - [ ] ContactFactory
  - [ ] ServiceFactory

### Testing (with Mocking)
- [ ] Set up test project with mocking framework
- [ ] Write tests for:
  - [ ] Services
  - [ ] Factories
  - [ ] ViewModels
  - [ ] Data validation

## Additional Tasks
- [x] Add input validation
- [ ] Add error handling
- [ ] Add logging
- [ ] Add user feedback messages
- [ ] Document code
- [ ] Create user guide 