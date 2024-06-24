import Breadcrumbs from '@mui/material/Breadcrumbs';
import Divider from '@mui/material/Divider';
import Grid from '@mui/material/Grid';
import Link from '@mui/material/Link';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import React from 'react';
import Chart from 'react-apexcharts';

// project import
import MainCard from 'components/MainCard';
import ComponentSkeleton from './ComponentSkeleton';

// ==============================|| COMPONENTS - TYPOGRAPHY ||============================== //

export default function charts() {
  const burnUpState = {
    options: {
      chart: {
        type: 'line',
        height: 350
      },
      xaxis: {
        type: 'datetime'
      },
      title: {
        text: 'Line Chart with Dates',
        align: 'left'
      },
      markers: {
        size: 0
      },
      yaxis: {
        title: {
          text: 'Value'
        }
      },
      tooltip: {
        shared: true,
        intersect: false,
        y: {
          formatter: function (val) {
            return val.toFixed(2);
          }
        }
      }
    },
    series: [
      {
        name: 'Done tasks',
        data: [
          [new Date('2023-01-01').getTime(), 30],
          [new Date('2023-01-02').getTime(), 40],
          [new Date('2023-01-03').getTime(), 35],
          [new Date('2023-01-04').getTime(), 50],
          [new Date('2023-01-05').getTime(), 49],
          [new Date('2023-01-06').getTime(), 60],
          [new Date('2023-01-07').getTime(), 70],
          [new Date('2023-01-08').getTime(), 91]
        ]
      },
      {
        name: 'Total tasks',
        data: [
          [new Date('2023-01-01').getTime(), 70],
          [new Date('2023-01-02').getTime(), 90],
          [new Date('2023-01-03').getTime(), 90],
          [new Date('2023-01-04').getTime(), 90],
          [new Date('2023-01-05').getTime(), 90],
          [new Date('2023-01-06').getTime(), 90],
          [new Date('2023-01-07').getTime(), 90],
          [new Date('2023-01-08').getTime(), 91]
        ]
      },
      {
        name: 'Ideal burn-up',
        data: [
          [new Date('2023-01-01').getTime(), 30],
          [new Date('2023-01-08').getTime(), 91]
        ]
      },
    ]
  };

    const ganttState = {
      options: {
        chart: {
          height: 350,
          type: 'rangeBar'
        },
        plotOptions: {
          bar: {
            horizontal: true,
            barHeight: '80%'
          }
        },
        xaxis: {
          type: 'datetime'
        },
        stroke: {
          width: 1
        },
        fill: {
          type: 'solid',
          opacity: 0.6
        },
        legend: {
          position: 'top',
          horizontalAlign: 'left'
        }
      },
      series: [
        {
          name: 'Goal One',
          data: [
            {
              x: 'Sub-goal A',
              y: [
                new Date('2023-01-01').getTime(),
                new Date('2023-01-05').getTime()
              ]
            },
            {
              x: 'Sub-goal B',
              y: [
                new Date('2023-01-10').getTime(),
                new Date('2023-01-20').getTime()
              ]
            },
            {
              x: 'Sub-goal C',
              y: [
                new Date('2023-02-01').getTime(),
                new Date('2023-02-14').getTime()
              ]
            }
          ]
        }
      ]
    };
  
  
  return (
    <Stack>
         <div id="burnup">
    <Typography variant="h2">Burn-up chart</Typography>
    <Chart options={burnUpState.options} series={burnUpState.series} type="line" height={350} />
    </div>
   <div id="gantt">
    <Typography variant="h2">Gantt chart</Typography>
      <Chart options={ganttState.options} series={ganttState.series} type="rangeBar" height={350} />
    </div>
    </Stack>
  );
}
