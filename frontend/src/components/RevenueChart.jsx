import React from "react";
import { Line } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Tooltip, Legend);

const RevenueChart = ({ labels, values, color, yLabel }) => {
  const data = {
    labels,
    datasets: [
      {
        label: yLabel,
        data: values,
        borderColor: color,
        backgroundColor: color,
        tension: 0.35,
        fill: false,
        pointRadius: 3,
      },
    ],
  };

  const options = {
    responsive: true,
    plugins: { legend: { display: false } },
    scales: {
      y: { beginAtZero: false, title: { display: true, text: yLabel } },
      x: { title: { display: true, text: "Year" } },
    },
  };

  return <Line data={data} options={options} height={220} />;
};

export default RevenueChart;
