import React, { useState } from 'react';
import axios from 'axios';
import {
    Container,
    Box,
    Card,
    TextField,
    Button,
    Typography,
    FormControl,
    MenuItem,
    Select,
    InputLabel,
    Alert,
} from '@mui/material';
import CalculateIcon from '@mui/icons-material/Calculate';
interface ShortestPathData {
    nodeNames: string[];
    distance: number;
}

const DijkstraCalculator: React.FC = () => {
    const [fromNode, setFromNode] = useState('');
    const [toNode, setToNode] = useState('');
    const [result, setResult] = useState<ShortestPathData | null>(null);
    const [error, setError] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await axios.get<ShortestPathData>(
                'https://localhost:7277/api/shortestpath',
                {
                    params: { from: fromNode, to: toNode },
                }
            );
            setResult(response.data);
            setError(null);
        } catch (err) {
            setError('An error occurred while calculating the shortest path.');
            setResult(null);
        }
    };

    const clearSelection = () => {
        setFromNode('');
        setToNode('');
        setResult(null);
        setError(null);
    };

    return (
        <Container
            maxWidth="sm"
            sx={{
                minHeight: '50vh',
                display: 'flex',
                alignItems: 'center',
                justifyContent: 'center',
            }}
        >
            <Card
                sx={{
                    p: 4,
                    minWidth: '300px',
                    minHeight: '300px',
                    maxWidth: '300px',
                    maxHeight: '300px',
                }}
            >
                <form onSubmit={handleSubmit} style={{ marginTop: '1rem' }}>
                    <FormControl fullWidth sx={{ mb: 3 }}>
                        <InputLabel>From Node</InputLabel>
                        <Select
                            value={fromNode}
                            onChange={(e) => setFromNode(e.target.value)}
                            label="From Node"
                        >
                            <MenuItem value="A">A</MenuItem>
                            <MenuItem value="B">B</MenuItem>
                            <MenuItem value="C">C</MenuItem>
                            <MenuItem value="D">D</MenuItem>
                            <MenuItem value="E">E</MenuItem>
                            <MenuItem value="F">F</MenuItem>
                            <MenuItem value="G">G</MenuItem>
                            <MenuItem value="H">H</MenuItem>
                            <MenuItem value="I">I</MenuItem>
                        </Select>
                    </FormControl>

                    <FormControl fullWidth sx={{ mb: 3 }}>
                        <InputLabel>To Node</InputLabel>
                        <Select
                            value={toNode}
                            onChange={(e) => setToNode(e.target.value)}
                            label="To Node"
                        >
                            <MenuItem value="A">A</MenuItem>
                            <MenuItem value="B">B</MenuItem>
                            <MenuItem value="C">C</MenuItem>
                            <MenuItem value="D">D</MenuItem>
                            <MenuItem value="E">E</MenuItem>
                            <MenuItem value="F">F</MenuItem>
                            <MenuItem value="G">G</MenuItem>
                            <MenuItem value="H">H</MenuItem>
                            <MenuItem value="I">I</MenuItem>
                        </Select>
                    </FormControl>

                    <Box display="flex" gap={2} justifyContent="center">
                        <Button
                            type="button"
                            variant="outlined"
                            color="warning"
                            onClick={clearSelection}
                        >
                            Clear
                        </Button>
                        <Button type="submit" variant="contained" color="warning" endIcon={<CalculateIcon />}>
                            Calculate
                        </Button>
                    </Box>
                </form>

                {error && (
                    <Alert severity="error" sx={{ mt: 3 }}>
                        {error}
                    </Alert>
                )}
            </Card>
            <Card
                sx={{
                    p: 4,
                    minWidth: '300px',
                    minHeight: '300px',
                    maxWidth: '300px',
                    maxHeight: '300px',
                    marginLeft: '0.1rem',
                }}
            >
                {result && (
                    <Box sx={{ mt: 3, textAlign: 'left' }}>
                        <Typography variant="subtitle1">
                            From Node Name: "{fromNode}", To Node Name: "{toNode}" : {result.nodeNames.join(', ')}
                        </Typography>
                        <br></br>
                        <Typography variant="subtitle1">
                            Total Distance: {result.distance}
                        </Typography>
                    </Box>
                )}
            </Card>
        </Container>
    );
};

export default DijkstraCalculator;
