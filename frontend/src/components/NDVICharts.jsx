import React from "react";
import { Line } from "react-chartjs-2";
import { Chart as ChartJS, CategoryScale, LinearScale, PointElement, LineElement, Tooltip, Legend } from "chart.js";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Tooltip, Legend);

const NDVIChart = () => {
  const data = {
    labels: Array.from({ length: 30 }, (_, i) => `Day ${i + 1}`),
    datasets: [
      {
        label: "Field 1",
        data: [0.3, 0.35, 0.4, 0.45, 0.55, 0.6, 0.65, 0.7, 0.68, 0.66, 0.65, 0.63, 0.62, 0.6, 0.59, 0.58, 0.56, 0.55, 0.54, 0.53, 0.52, 0.5, 0.48, 0.47, 0.45, 0.43, 0.42, 0.4, 0.38, 0.35],
        borderColor: "green",
        fill: false,
        tension: 0.3,
      },
      {
        label: "Field 2",
        data: [0.2, 0.25, 0.3, 0.32, 0.38, 0.4, 0.42, 0.44, 0.45, 0.46, 0.45, 0.44, 0.43, 0.41, 0.4, 0.38, 0.37, 0.36, 0.35, 0.34, 0.33, 0.32, 0.3, 0.28, 0.27, 0.26, 0.25, 0.24, 0.23, 0.22],
        borderColor: "blue",
        fill: false,
        tension: 0.3,
      },
      {
        label: "Field 3",
        data: [0.1, 0.12, 0.15, 0.18, 0.21, 0.24, 0.26, 0.27, 0.29, 0.3, 0.32, 0.31, 0.3, 0.29, 0.28, 0.27, 0.26, 0.25, 0.24, 0.22, 0.21, 0.2, 0.18, 0.17, 0.16, 0.15, 0.14, 0.13, 0.12, 0.1],
        borderColor: "red",
        fill: false,
        tension: 0.3,
      },
    ],
  };

  const options = {
    responsive: true,
    plugins: {
      legend: { position: "top" },
      tooltip: { mode: "index", intersect: false },
    },
    scales: {
      y: { min: 0, max: 1, title: { display: true, text: "NDVI" } },
      x: { title: { display: true, text: "Day" } },
    },
  };

  return (
    <div className="chart-container">
      <h3>NDVI Trend</h3>
      <Line data={data} options={options} />
    </div>
  );
};

export default NDVIChart;
