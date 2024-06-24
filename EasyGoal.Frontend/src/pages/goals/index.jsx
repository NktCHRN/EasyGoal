import React, { useEffect, useState } from "react";

// material-ui
import Grid from '@mui/material/Grid';
import Pagination from '@mui/material/Pagination';
import Box from '@mui/material/Box';
import Fab from '@mui/material/Fab'
import { useTheme } from '@mui/material/styles';

import {enqueueSnackbar} from 'notistack'

// project import
import PersonalGoalCard from 'components/cards/statistics/PersonalGoal';
import Search from './SearchGoals'
import { Tooltip } from '@mui/material';
import { getUserGoals } from 'services/goalService';


export default function UserGoals() {
  const theme = useTheme();
  
  const fabStyle = {
    position: 'fixed',
    right: theme.spacing(5),
    bottom: theme.spacing(5),
  };

  const perPageCount = 12;

  const [currentPage, setCurrentPage] = useState(1);
  const [goals, setGoals] = useState([]);
  const [totalCount, setTotalCount] = useState(0);

  useEffect(() => {
    getUserGoals(null, currentPage, perPageCount)
      .then(r => 
        {
          setGoals(r.goals);
          setTotalCount(r.totalCount);
        }
      )
      .catch(e => enqueueSnackbar(e.message))
  }, [currentPage])

  return (
    <>
    <Grid container rowSpacing={4.5} columnSpacing={2.75}>
      <Grid item xs={12} sm={12} md={12} lg={12}>
      <Search></Search>
        </Grid>
        {goals.map((goal) => (
          <Grid item xs={12} sm={6} md={4} lg={3}>
          <PersonalGoalCard name={goal.name} description={goal.description} doneTasks={goal.doneTasks} totalTasks={goal.totalTasks} deadline={goal.deadline} doneTasksPercentage={goal.doneTasksPercentage} />
        </Grid>
        ))}
      <Grid item xs={12} sm={12} md={12} lg={12}>
      <Box display="flex" justifyContent="center">
        <Pagination count={totalCount == 0 ? 1 : Math.ceil(totalCount / perPageCount)} variant="outlined" />
        </Box>
      </Grid>
    </Grid>
    <Tooltip title="Add personal goal">
      <Fab color='primary' size="large" sx={fabStyle}>
              +
            </Fab>
    </Tooltip>
    </>
  );
}
