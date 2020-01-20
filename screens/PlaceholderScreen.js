import React from 'react';
import { ScrollView, StyleSheet } from 'react-native';

export default function PlaceholderScreen() {
  return (
    <ScrollView style={styles.container}>

    </ScrollView>
  );
}

PlaceholderScreen.navigationOptions = {
  title: 'Placeholder',
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 15,
    backgroundColor: '#fff',
  },
});
