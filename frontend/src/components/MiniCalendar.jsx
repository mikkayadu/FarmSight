import React from "react";
import { Bar } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(CategoryScale, LinearScale, BarElement, Tooltip, Legend);

const monthLabels = [
  "Jan", "Feb", "Mar", "Apr", "May", "Jun",
  "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
];

// helper to convert [start, end] into 12-value array
const buildBar = (range, color) => {
  const arr = Array(12).fill(0);
  if (range) {
    const [s, e] = range;
    for (let i = s; i < e; i++) arr[i] = 1;
  }
  return {
    data: arr,
    backgroundColor: color,
    borderWidth: 0,
    stack: "stack",
  };
};

const MiniCalendar = ({ data }) => {
  // each crop row becomes a dataset group
  const datasets = [];
  data.forEach((row, i) => {
    datasets.push(
      {
        label: `${row.crop} — sow`,
        ...buildBar(row.sow, "#7cb342"),
        barPercentage: 0.9,
        categoryPercentage: 0.8,
        order: i * 3 + 1,
      },
      {
        label: `${row.crop} — grow`,
        ...buildBar(row.grow, "#fbc02d"),
        order: i * 3 + 2,
      },
      {
        label: `${row.crop} — harvest`,
        ...buildBar(row.harvest, "#e64a19"),
        order: i * 3 + 3,
      }
    );
  });

  const options = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: { legend: { display: false }, tooltip: { intersect: false } },
    indexAxis: "y",
    scales: {
      x: { stacked: true, display: false, max: 1 },
      y: { stacked: true, display: false },
    },
  };

  return (
    <div className="mini-chart">
      <Bar data={{ labels: monthLabels, datasets }} options={options} height={120} />
    </div>
  );
};

export default MiniCalendar;
