# Dijkstra's Algorithm Calculator

## Description

This project implements a web-based Dijkstra's Algorithm Calculator using React and Material-UI. It provides a user-friendly interface for calculating the shortest path between nodes in a graph using Dijkstra's algorithm.

## Features

- Interactive UI for selecting start and end nodes
- Visualization of the shortest path and total distance
- Responsive design that works on desktop and mobile devices
- Clear and Calculate functionality
- Integration with backend API for path calculations

## Technologies Used

- React 18
- Material-UI (MUI) 5
- TypeScript
- ASP .net 8 (for the development environment)

## Prerequisites

Before you begin, ensure you have met the following requirements:

- Node.js (v14.0.0 or later)
- npm (v6.0.0 or later)

## Installation

1. Clone the repository:
git clone [https://github.com/rashmika-prabhath/Dijkstra-s-Algorithm-Calculator](https://github.com/rashmika-prabhath/Dijkstra-s-Algorithm-Calculator)


2. Navigate to the project directory:
cd dijkstra-calculator


3. Install the dependencies:
npm install


## Usage

To run the application in development mode:

npm start


This will start the development server. Open [http://localhost:5173](http://localhost:5173) to view it in the browser.

## Building for Production

To build the app for production:

npm run build


This will create a `build` directory with a production build of your app.

## API Integration

The calculator is designed to work with a backend API that implements Dijkstra's algorithm. To connect to your API:

1. Open `src/components/DijkstraCalculator.tsx`
2. Locate the `handleCalculate` function
3. Replace the mock result with an actual API call, for example:

```typescript
const handleCalculate = async () => {
  try {
    const response = await fetch(`/api/shortestPath?from=${fromNode}&to=${toNode}`);
    const data = await response.json();
    setResult(data);
  } catch (error) {
    console.error('Error calculating path:', error);
  }
};
Customization
To modify the theme or colors, edit the theme object in src/DijkstraCalculator.tsx
To add or remove nodes, modify the nodes array in the same file
Contributing
Contributions to this project are welcome. Please follow these steps:

Fork the repository
Create a new branch (git checkout -b feature/AmazingFeature)
Make your changes
Commit your changes (git commit -m 'Add some AmazingFeature')
Push to the branch (git push origin feature/AmazingFeature)
Open a Pull Request
License
This project is licensed under the MIT License - see the LICENSE.md file for details.

Contact
Rashmika Prabhath - your.rashmikapb@gmail.com

Project Link: [https://github.com/rashmika-prabhath/Dijkstra-s-Algorithm-Calculator](https://github.com/rashmika-prabhath/Dijkstra-s-Algorithm-Calculator)
Acknowledgements
React
Material-UI
Dijkstra's Algorithm
