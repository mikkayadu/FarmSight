import {
  LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer,
} from 'recharts';

const sampleData = [
  { date: 'Week 1', NDVI: 0.32 },
  { date: 'Week 2', NDVI: 0.45 },
  { date: 'Week 3', NDVI: 0.38 },
  { date: 'Week 4', NDVI: 0.52 },
];

function NDVIChart() {
  return (
    <div className="bg-white p-4 rounded shadow w-full h-64">
      <h3 className="text-lg font-semibold mb-4">NDVI Over Time</h3>
      <ResponsiveContainer width="100%" height="100%">
        <LineChart data={sampleData}>
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey="date" />
          <YAxis domain={[0, 1]} />
          <Tooltip />
          <Legend />
          <Line type="monotone" dataKey="NDVI" stroke="#38a169" strokeWidth={2} />
        </LineChart>
      </ResponsiveContainer>
    </div>
  );
}

export default NDVIChart;
