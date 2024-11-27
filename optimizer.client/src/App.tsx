import React from 'react';
import { CssBaseline, Container, Typography, Box } from '@material-ui/core';
import DijkstraCalculator from './components/DijkstraCalculator';

const App: React.FC = () => {
    return (
        <>
            <CssBaseline />
            <>
                <Container style={{marginTop: '5%', marginLeft:'65%'}}>
                    <Typography style={{ color: '#fdfdfd' }} variant="h4" align="center">Dijkstra's Algorithm Calculator</Typography>
                    <Typography style={{ color: '#fdfdfd' }} variant="h6" align="center">Discovering Optimal Routes Through Nodes Using Dijkstra's Method</Typography>
                    <DijkstraCalculator />
                </Container>
            </>
        </>
    );
};

export default App;